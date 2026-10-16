module.exports = {
  content: [
    './src/**/*.{js,jsx,ts,tsx}',
  ],
  daisyui: {
    themes: [
    {
      fundzotheme: {
        'primary': '#ABCB0B',
        'secondary': '#f2f7d8',
        'accent': '#40B2D0',
        'warning': '#FFB836',
        'success': '#748A06',
        'error' : '#FF6550',
        'neutral': '#6F6F6F',
        'base-100': '#FFFFFF',
        'base-200': '#F8F8F8',
        'base-300': '#F1F1F1',
        'base-content': '#050504',
      },
    },
  ],
  darkTheme: 'dark',
  },
  plugins: [
    require('daisyui'),
  ],
}
