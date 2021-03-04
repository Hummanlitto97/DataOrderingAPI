# DataOrderingAPI
Small Data Ordering API project in DDD.
DDD is not necessary on such small projects and I wouldn't recommend it unless you will keep it for future expansions and easier management as well as testing

## Use Cases

You want to order primitive data types in ascending way -> string, int, double

## Endpoints

```http
GET /{type}/{data}
```

Responses with ordered data and saves it in server as .txt file. Every call overwrites previous file

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `type` | `string` | **Required**. Primitive types (Only alphabet letters) |
| `data` | `string` | **Required**. Your data that you want to order (Ascending). **Delimeter is empty space -> %20 ** |

| Primtive Type | {type} |
| :--- | :--- |
| `Integer` | `Int` |
| `Double` | `Double` |
| `String` | `String` |

```http
GET /lastData
```

Responses with saved file content

| Parameter | Type | Description |
| :--- | :--- | :--- |
| `-` | `-` | - |

## Responses

JSON: 

```javascript
{
  "{data}" : {data_type}
}
```
## Examples
```http
GET /Int/4%207%201%20
```
Response:
```javascript
{
  "1",
  "4",
  "7"
}
```
```http
GET /lastData
```
Response:
```javascript
{
  "1 4 7"
}
```
## Status Codes

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 400 | `BAD REQUEST/INTERNAL ERROR` |
| 501 | `NOT FULLY IMPLEMENTED` |
