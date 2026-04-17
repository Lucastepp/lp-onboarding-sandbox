# API Contracts

## Purpose

This document defines the API contracts for the merchant onboarding flow.

The first implementation focuses on the Signup step.
Additional contracts are planned for later stages.

---

## Implemented First

### POST /api/onboarding/signup

Creates a new lead and starts the onboarding flow after the user completes the Signup step.

### Request

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

### Response

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

Retrieves the onboarding record by leadId.

### Response

```json
{
  "leadId": "guid",
  "status": "InProgress",
  "lastCompletedStep": "Signup",
  "currentStep": "CompanyDetails"
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

### SignupResponse

Represents the response returned by the API.

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

### PUT /api/onboarding/{leadId}/company-details

Updates onboarding with company information.

Possible fields:

- companyName
- companyNumber
- registeredAddress
- tradingAddress
- industry
- annualRevenue

---

### PUT /api/onboarding/{leadId}/personal-details

Updates onboarding with personal information.

Possible fields:

- dateOfBirth
- nationality
- residentialAddress
- employmentStatus

---

### PUT /api/onboarding/{leadId}/financial-details

Captures financial information required for underwriting.

Possible fields:

- bankStatements
- openBankingConsent
- openBankingProvider
- uploadedDocuments
- declaredRevenue
- declaredExpenses

Financial details may be provided either by document upload (e.g. PDF bank statements) or through Open Banking integration.

---

### GET /api/onboarding/{leadId}/progress

Returns current onboarding progress.

Possible response fields:

- leadId
- status
- lastCompletedStep
- currentStep

---

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

- The API does not return routes such as "/company-details"
- The UI is responsible for routing
- The backend is the source of truth for onboarding progress
- Only the Signup contract and the basic Get By LeadId flow are implemented initially
- Other contracts will be refined later

---

## Behavior

- When a signup request is received, a new lead is created
- The onboarding is stored in memory (temporary persistence)
- The initial state is:
  - status: InProgress
  - lastCompletedStep: Signup
  - currentStep: CompanyDetails
- The API returns the leadId for future steps
