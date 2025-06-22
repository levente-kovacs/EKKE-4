import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ChatRequest } from '../../model/interface/chat-request';
import { ChatService } from '../../service/chat.service';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MarkdownModule } from 'ngx-markdown';

@Component({
  selector: 'app-mini-chat',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MarkdownModule],
  templateUrl: './mini-chat.component.html',
  styleUrl: './mini-chat.component.scss'
})
export class MiniChatComponent {
  prompt = '';
  response = '';
  loading = false;
  mode: ChatRequest['mode'] = 'answer';

  constructor(private chat: ChatService) {}

  private buildPrompt(input: string, mode: ChatRequest['mode']): string {
    const promptPrefixes: Record<ChatRequest['mode'], string> = {
      answer: 'Válaszolj röviden, maximum 1 mondatban pontosan: ',
      translate: 'Fordítsd le angol nyelvre pontosan: ',
      rephrase: 'Fogalmazd újra udvariasabban: ',
    };

    const prefix = promptPrefixes[mode] ?? '';
    return `${prefix}${input.trim()}`;
  }

  ask(): void {
    const trimmed = this.prompt.trim();
    if (!trimmed) return;

    this.loading = true;
    this.response = '';

    const finalPrompt = this.buildPrompt(trimmed, this.mode);

    this.chat.askLLM({ input: finalPrompt, mode: this.mode }).subscribe({
      next: res => (this.response = res.output),
      error: () => (this.response = 'Hiba történt a válasz lekérésekor.'),
      complete: () => (this.loading = false),
    });
  }
}
