# Signup Flow

## Objective

Implement the first step of the merchant onboarding journey.

This step collects initial user data and creates a new onboarding record.

---

## User Journey

1. User opens the Signup page
2. User fills in the form:
   - first name
   - last name
   - email
   - password
   - phone number
   - country
3. UI performs basic validation
4. User clicks "Next"
5. UI sends a POST request to the API
6. API validates the request
7. API calls domain logic to create the onboarding
8. Domain sets initial status and step
9. Data is stored (in-memory for now)
10. API returns a response
11. UI receives the response
12. UI navigates to the next step (Company Details)

---

## Flow Summary

UI → API → Domain → Save → Response → UI → Next Page

---

## Initial Rules

- email is required
- password is required
- password must meet minimum length
- country is required
- email must be unique (checked in backend)

---

## Output

After successful signup, the system returns:

- onboardingId (GUID)
- status (e.g., InProgress)
- lastCompletedStep (Signup)
- currentStep (CompanyDetails)

---

## Notes

- No authentication is implemented at this stage
- The focus is on onboarding flow, not login
- Backend is responsible for tracking progress
- UI reacts to API response and controls navigation
