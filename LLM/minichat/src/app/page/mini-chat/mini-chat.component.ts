import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ChatRequest } from '../../model/interface/chat-request';
import { ChatService } from '../../service/chat.service';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-mini-chat',
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule],
    templateUrl: './mini-chat.component.html',
  styleUrl: './mini-chat.component.scss'
})
export class MiniChatComponent {
  prompt = '';
  mode: ChatRequest['mode'] = 'answer';
  response = '';
  loading = false;

  constructor(private chat: ChatService) {}

  ask() {
    if (!this.prompt.trim()) return;
    this.loading = true;

    this.chat.askLLM({ input: this.prompt, mode: this.mode }).subscribe({
      next: res => this.response = res.output,
      error: () => this.response = 'Hiba történt.',
      complete: () => this.loading = false
    });
  }
}
