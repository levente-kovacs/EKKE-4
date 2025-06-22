import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {

  private readonly THEME_KEY = 'theme-mode';
  private darkClass = 'dark-theme';
  private lightClass = 'light-theme';

  constructor() {
    const savedTheme = localStorage.getItem(this.THEME_KEY);
    if (savedTheme === 'dark' || savedTheme === 'light') {
      this.applyTheme(savedTheme);
    } else {
      this.applyTheme('dark'); // vagy az alapértelmezett
    }
  }

  toggle(): void {
    const isDark = this.isDark();
    const newTheme = isDark ? 'light' : 'dark';
    this.applyTheme(newTheme);
  }

  isDark(): boolean {
    return document.documentElement.classList.contains(this.darkClass);
  }

  private applyTheme(theme: 'light' | 'dark'): void {
    const root = document.documentElement;
    root.classList.remove(this.darkClass, this.lightClass);
    root.classList.add(theme === 'dark' ? this.darkClass : this.lightClass);
    localStorage.setItem(this.THEME_KEY, theme);
  }
}
