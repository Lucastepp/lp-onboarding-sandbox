# API Contracts

## Purpose

This document defines the API contracts for the merchant onboarding flow.

The first implementation focuses on the Signup step.
Additional contracts are planned for later stages.

---

## Implemented First

### POST /api/onboarding/signup

Creates a new onboarding record after the user completes the Signup step.

---

## Request

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

---

## Response

{
"onboardingId": "guid",
"status": "InProgress",
"lastCompletedStep": "Signup",
"currentStep": "CompanyDetails"
}

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

- onboardingId: Guid
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
- ReviewInformation
- ReviewOffer
- LoanDetails
- Completed

---

## Planned Next Contracts

### PUT /api/onboarding/{id}/company-details

Updates onboarding with company information.

Possible fields:

- companyName
- companyNumber
- registeredAddress
- tradingAddress
- industry
- annualRevenue

---

### PUT /api/onboarding/{id}/personal-details

Updates onboarding with personal information.

Possible fields:

- dateOfBirth
- nationality
- residentialAddress
- employmentStatus

---

### GET /api/onboarding/{id}/progress

Returns current onboarding progress.

Possible response fields:

- onboardingId
- status
- lastCompletedStep
- currentStep

---

### GET /api/onboarding/{id}/offers

Returns available offers.

Possible response fields:

- offerId
- amount
- term
- repayment
- status

---

### POST /api/onboarding/{id}/select-offer

Selects an offer.

Possible request fields:

- offerId

---

### POST /api/onboarding/{id}/loan-details

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
- Only the Signup contract is implemented initially
- Other contracts will be refined later
