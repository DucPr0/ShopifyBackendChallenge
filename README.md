# ShopifyBackendChallenge
Source code for Shopify's Backend Developer Intern challenge.

https://docs.google.com/document/d/1PoxpoaJymXmFB3iCMhGL6js-ibht7GO_DkCF2elCySU/edit

# Replit
URL: https://replit.com/@littleguy3/ShopifyBackendChallenge

The application does not have an UI, so curl must be used to create requests.

The Repl has to be forked in order to access a shell to create and execute curl queries. After forking, press 'Run' to launch the application.

Example are below:

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
    "name": "Vase",
    "country": "China"
  },
  {
    "name": "Car",
    "country": "America"
  }
]'
```
or for an inline version:
```
curl -X POST localhost:5257/inventory -H 'Content-Type: application/json' -d '[{ "name": "Vase", "country": "China" }, { "name": "Car", "country": "America" }]'
```

Update:
```
curl -X PUT localhost:5257/inventory \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "name": "Vase",
  "country": "Germany"
}'
```
or for an inline version:
```
curl -X PUT localhost:5257/inventory -H 'Content-Type: application/json' -d '{ "id": 1, "name": "Vase", "country": "Germany" }'
```

Delete:
```
curl -X DELETE localhost:5257/inventory/{id} -d '{ "deleteReason": "shipped" }'
```

Undelete item:
```
curl -X PUT localhost:5257/inventory/restore/{id}
```

View the most recently deleted items: 
```
curl -X GET localhost:5257/inventory/deleted
```
