# Deployment

## Local
1. Configure Azure OpenAI variables when using a live model: `AZURE_OPENAI_ENDPOINT`, `AZURE_OPENAI_DEPLOYMENT`, `AZURE_OPENAI_API_KEY`.
2. Run `docker compose up --build`.
3. Open `http://localhost:5173`.

## Azure
Use `infra/main.bicep` as the App Service baseline. Add Azure OpenAI, Azure AI Search, and Microsoft Entra ID settings in the Azure portal or CI/CD secrets.
