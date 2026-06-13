param location string = resourceGroup().location
param appName string = 'factoryiq-agent'
resource plan 'Microsoft.Web/serverfarms@2023-12-01' = { name: '${appName}-plan' location: location sku: { name: 'B1' } }
resource app 'Microsoft.Web/sites@2023-12-01' = { name: appName location: location properties: { serverFarmId: plan.id httpsOnly: true } }
