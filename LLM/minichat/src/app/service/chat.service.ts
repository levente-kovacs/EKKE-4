import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { ChatRequest } from '../model/interface/chat-request';
import { ChatResponse } from '../model/interface/chat-response';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  private readonly apiUrl = environment.apiUrl;
  private readonly apiKey = environment.huggingfaceApiKey;

  constructor(private http: HttpClient) {}

  askLLM(request: ChatRequest): Observable<ChatResponse> {
    const fullPrompt = this.buildPrompt(request);

    const headers = new HttpHeaders({
      Authorization: this.apiKey,
      'Content-Type': 'application/json',
    });

    return this.http
      .post<any>(this.apiUrl, { inputs: fullPrompt }, { headers })
      .pipe(map(res => ({ output: res[0]?.generated_text || 'Nincs válasz.' })));
  }

  private buildPrompt(req: ChatRequest): string {
    switch (req.mode) {
      case 'translate':
        return `Translate this to English:\n${req.input}`;
      case 'rephrase':
        return `Rephrase this politely:\n${req.input}`;
      default:
        return `Answer briefly:\n${req.input}`;
    }
  }
}
