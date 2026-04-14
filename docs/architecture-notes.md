# Architecture Notes

## Overview

This project simulates a simplified merchant onboarding system, focusing on clean architecture, separation of concerns, and a realistic end-to-end flow.

The system is divided into the following main layers:

- UI (Angular)
- API (.NET)
- Domain
- Persistence
- Event / Integration

---

## Responsibilities

### UI (Angular)

Responsible for:

- rendering pages and forms
- handling user interaction
- performing basic validation
- calling the API
- handling responses (success/error)
- navigating between onboarding steps
- managing temporary state (via services)

---

### API (.NET)

Responsible for:

- receiving HTTP requests
- validating input
- orchestrating the flow
- calling domain logic
- returning responses to the UI

---

### Domain

Responsible for:

- business rules
- core entities (e.g., Onboarding)
- onboarding status and step tracking
- ensuring valid transitions between steps

---

### Persistence

Responsible for:

- storing onboarding data
- retrieving onboarding progress
- starting with in-memory storage
- can be replaced with a real database later

---

### Event / Integration

Responsible for:

- publishing events (e.g., onboarding created)
- transforming internal events into external formats
- simulating integration with other systems

---

## Key Design Decisions

- Keep the first version simple and focused on one complete flow
- Use in-memory persistence initially
- Avoid premature complexity (no auth, no SignalR at the start)
- Separate concerns across layers
- Let the backend be the source of truth for onboarding progress

---

## Future Improvements

- Add real database
- Introduce authentication and authorization
- Add async processing and events
- Add real-time updates (e.g., SignalR)
- Improve validation and error handling
