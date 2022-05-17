# ShopifyBackendChallenge
Source code for Shopify's Backend Developer Intern challenge.

https://docs.google.com/document/d/1PoxpoaJymXmFB3iCMhGL6js-ibht7GO_DkCF2elCySU/edit

# Replit
Press 'Run' on Replit to launch the application.

The application does not have an UI, so curl must be used to create requests. Example commands are as belows:

Get:
```
curl -X GET localhost:5257/inventory
```

Create (supports creating multiple items at once):
```
curl -X POST localhost:5257/inventory \
  -H 'Content-Type: application/json' \
  -d '[
  {
    "name": "itemName",
    "country": "itemCountry"
  },
  {
    "name": "itemName2",
    "country": "itemCountry2"
  }
]'
```

Update:
```
curl -X PUT localhost:5257/inventory \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0,
  "name": "string",
  "country": "string"
}'
```

Delete:
```
curl -X DELETE localhost:5257/inventory/1
```
