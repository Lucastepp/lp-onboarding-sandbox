# API Contracts

## Purpose

This document defines the API contracts for the merchant onboarding flow.

The onboarding is implemented as a step-based process where the backend is responsible for tracking progress and state.

---

## Implemented Endpoints

### POST /api/onboarding/signup

Creates a new lead and starts the onboarding flow after the user completes the Signup step.

#### Request

```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string",
  "phoneNumber": "string",
  "country": "string",
  "device": {
    "type": "Desktop | Mobile",
    "browser": "string",
    "language": "string",
    "timezone": "string"
  }
}
```

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "Signup",
  "currentStep": "CompanyDetails"
}
```

---

### GET /api/onboarding/{leadId}

Retrieves the onboarding summary by leadId.

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "Signup",
  "currentStep": "CompanyDetails"
}
```

---

### GET /api/onboarding/{leadId}/progress

Returns the current onboarding progress.

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "FinancialDetails",
  "currentStep": "ReviewInformation"
}
```

---

### PUT /api/onboarding/{leadId}/company-details

Updates onboarding with company information.

#### Request

```json
{
  "companyName": "string",
  "companyNumber": "string",
  "registeredAddress": "string",
  "tradingAddress": "string",
  "industry": "string",
  "annualRevenue": 0
}
```

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "CompanyDetails",
  "currentStep": "PersonalDetails"
}
```

---

### PUT /api/onboarding/{leadId}/personal-details

Updates onboarding with personal information.

#### Request

```json
{
  "dateOfBirth": "2024-01-01",
  "nationality": "string",
  "residentialAddress": "string",
  "employmentStatus": "string"
}
```

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "PersonalDetails",
  "currentStep": "FinancialDetails"
}
```

---

### PUT /api/onboarding/{leadId}/financial-details

Captures financial information required for underwriting.

#### Request

```json
{
  "useOpenBanking": true,
  "hasUploadedDocuments": false,
  "annualRevenue": 0,
  "monthlyRevenue": 0,
  "monthlyExpenses": 0
}
```

#### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "FinancialDetails",
  "currentStep": "ReviewInformation"
}
```

---

## Models

### SignupRequest

Represents the payload sent from the UI to the API.

Fields:

- firstName: string
- lastName: string
- email: string
- password: string
- phoneNumber: string
- country: string
- device: DeviceInfo

---

### DeviceInfo

Represents client device metadata.

Fields:

- type: string (Desktop | Mobile)
- browser: string
- language: string
- timezone: string

---

### OnboardingResponse

Represents the shared response returned by onboarding step endpoints.

Fields:

- leadId: Guid
- status: OnboardingStatus
- lastCompletedStep: OnboardingStep
- currentStep: OnboardingStep

---

## Enums

### OnboardingStatus

Represents the overall onboarding state.

- InProgress
- PendingReview
- OfferAvailable
- Submitted
- Approved
- Rejected

---

### OnboardingStep

Represents onboarding progress.

- Signup
- CompanyDetails
- PersonalDetails
- FinancialDetails
- ReviewInformation
- ReviewOffer
- LoanDetails
- Completed

---

## Planned Next Contracts

### GET /api/onboarding/{leadId}/offers

Returns available offers.

Possible response fields:

- offerId
- amount
- term
- repayment
- status

---

### POST /api/onboarding/{leadId}/select-offer

Selects an offer.

Possible request fields:

- offerId

---

### POST /api/onboarding/{leadId}/loan-details

Captures loan-related details.

Possible fields:

- requestedAmount
- purpose
- repaymentPreference

---

## Notes

- The API does not return UI routes such as "/company-details"
- The UI is responsible for routing and navigation
- The backend is the source of truth for onboarding progress
- The onboarding is currently stored in memory (temporary persistence)
- Signup, Company Details, Personal Details, Financial Details and Progress endpoints are implemented
- Offer and loan-related endpoints are planned for future implementation

---

## Behavior

- When a signup request is received, a new lead is created

- The onboarding is stored in memory

- The initial state is:
  - status: InProgress
  - lastCompletedStep: Signup
  - currentStep: CompanyDetails

- After company details are completed:
  - lastCompletedStep: CompanyDetails
  - currentStep: PersonalDetails

- After personal details are completed:
  - lastCompletedStep: PersonalDetails
  - currentStep: FinancialDetails

- After financial details are completed:
  - lastCompletedStep: FinancialDetails
  - currentStep: ReviewInformation

- The API returns the leadId for all subsequent steps
