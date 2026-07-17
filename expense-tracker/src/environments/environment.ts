export const environment = {
  production: false,
  supabaseUrl: (import.meta as any).env.SUPABASE_URL,
  supabaseKey: (import.meta as any).env.SUPABASE_PUBLISHABLE_KEY
};