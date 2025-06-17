export interface ChatRequest {
  input: string;
  mode: 'answer' | 'translate' | 'rephrase';
}
