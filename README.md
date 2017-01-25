# GSTN 
GSTN API Client

This project is a strongly typed client for GSTN APIs as per http://developer.gstsystem.co.in/apiportal/

This work was born due to GST integration in Risersoft Maximprise manufacturing ERP (www.risersoft.com).

We are releasing it into open source for the benefit of community and in accordance with our belief that GST requires rigorous collaboration on the part of everybody in the ecosystem.

Going forward, we intend to maintain this as per the APIs released by GSTN. We solicit support and suggestions of the community in this regard.

Usage:
- GSTN is constantly evolving the APIs. Current version is 0.1
- Hence, it is recommended to use the GSTN.API.Library.dll directly in your projects
- This will enable easy updation in case of change

Status:

| API    | Implemented           | Pending               | 
|--------|-----------------------|-----------------------|
| Auth   | OTPRequest, AuthToken | RefreshToken          |
| GSTR1  | Get, Save             | File - Esign + DSC    |
| GSTR2  | Get, Save             |     -do-              |
| GSTR3  | Get, Save             |     -do-              |
| Legder | Get, Save             |                       |

Star Attraction
- JSON to CSV conversion
- CSV to JSON conversion
- Try on http://www.risersoft.com/community/gst/convert

| TODO                                                     |
|----------------------------------------------------------|
|  - Multi File Get                                        | 
|  - Error Codes                                           | 
|  - Sample Pass Through Web API for GSP use               |



