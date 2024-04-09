# TotvsTFS Discord Bot

Este é um projeto que roda como Azure Functions, que irá se portar como um Bot para Discord que manda uma mensagem a partir de uma ação no AzureDevOps, como por exemplo a criação de um PR.

## 🚀 Começando

Você precisará configurar os três pré-requisitos abaixo para ter o bot funcionando.

### 📋 Pré-requisitos

* [ServiceHook no Azure DevOps](https://totvstfs.visualstudio.com/Framework-BH/_settings/serviceHooks)
* [Environment Variable no Function APP](https://learn.microsoft.com/en-us/azure/azure-functions/functions-how-to-use-azure-function-app-settings?tabs=portal) - "urlWebhook": "https://discord.com/api/webhooks/1111111111111111111111"
* [WebHook no Discord](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks) - Edit Channel / Integrations / WebHook / New Webhook

