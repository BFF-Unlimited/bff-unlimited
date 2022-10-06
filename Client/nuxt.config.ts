import { defineNuxtConfig } from 'nuxt';
import eslintPlugin from 'vite-plugin-eslint';

// https://v3.nuxtjs.org/api/configuration/nuxt.config
export default defineNuxtConfig({
  srcDir: 'src',
  css: ['@/styles/index.css'],
  vite: {
    plugins: [eslintPlugin()],
    server: {
      hmr: {
        port: 5001,
      },
    },
  },
  runtimeConfig: {
    public: {
      baseURL: process.env.BASE_URL || 'https://localhost:5001',
    },
  },
  dirs: [
    // Scan top-level modules
    'composables/index.ts',
  ],
});
