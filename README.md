# ASP.NET Core Versioning

Versioning a Web API can be done in multiple ways:

|      | Approach                   | Example                                                |
| ---- | -------------------------- | ------------------------------------------------------ |
| 1    | Version in URI             | `/api/v1/products`                                     |
| 2    | Version in Query Parameter | `/api/products?version=1`                              |
| 3    | Version in Header          | `API-Version: 1`                                       |
| 4    | Version in Media-Type      | `Media-Type: application/vnd.dust-in-the-wind.v1+json` |

## Demo Application

The dummy Web API application provides a single endpoint:

- `GET /info/version`

This endpoint is implemented in both versions (v1 and v2) using one of the strategies described above.

See different branches for each of the strategies.

## Tutorial

Please see also the tutorial document on each branch:

- [Tutorial](/doc/tutorial/README.md)