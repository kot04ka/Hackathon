module.exports = {
  root: true,
  env: { browser: true, es2022: true },
  extends: [
    'airbnb',
    'airbnb/hooks',
    'plugin:@typescript-eslint/recommended',
    'plugin:react-hooks/recommended',
  ],
  ignorePatterns: ['dist', '.eslintrc.cjs'],
  parser: '@typescript-eslint/parser',
  plugins: ['react-refresh'],
  rules: {
    'max-len': 'off',
    'import/prefer-default-export': 0,
    'import/no-unresolved': 0,
    'import/extensions': 0,
    'react/jsx-filename-extension': [1, { "extensions": [".ts", ".tsx"] }],
    'react/no-array-index-key': 'off',
    'react/function-component-definition': [2, { "namedComponents": "arrow-function" }],
    'react-refresh/only-export-components': [
      'warn',
      { allowConstantExport: true },
    ],
  },
}
