# **Mini Unity Game with Email Notifications (SMTP)**

This project consists of a mini video game developed in **Unity**, whose main purpose is to demonstrate the functional integration between:

- Game logic  
- Basic user interface  
- Dynamic message generation  
- Real email sending using SMTP  

The game complexity is intentionally simple, since the focus is on the **email notification system** and its correct integration.

---

## **General Game Description**

The player controls a character that moves through the scene and interacts with different objects:

- **Positive object**: increases the player’s score.
- **Negative object**: resets the score to 0.
- **Special event**: occurs when an additional condition is met.

Each of these events triggers an **email notification**, sent to the address entered by the user through the interface.

---

##  **Event That Triggers the Notification**

```text
Player controls the character
        ↓
The character collides with an object in the scene
        ↓
Unity detects the collision (OnTriggerEnter)
        ↓
The type of collided object is evaluated
        ↓
• Positive object  → score increases
• Negative object  → score resets to 0
• Special event   → additional condition fulfilled
        ↓
The game event result is determined
        ↓
The email notification system is triggered
```

## **Video**
Link: https://youtu.be/FqHSawGauqU

## **SMTP Flow**

Victory Event

``` text
The player collides with a positive object
        ↓
The player score increases
        ↓
The score reaches 10 points
        ↓
The game detects a victory condition
        ↓
The email notification process is triggered
        ↓
The email subject is dynamically generated
        ↓
The email body is dynamically generated
        ↓
The MailMessage object is created
        ↓
Sender and recipient email addresses are assigned
        ↓
The SMTP client is configured
        ↓
Connection is established with smtp.gmail.com (port 587, SSL)
        ↓
The email is sent successfully
```

Defeat Event
``` text

The player collides with a negative object
        ↓
The player score is reset to 0
        ↓
The game detects a defeat condition
        ↓
The email notification process is triggered
        ↓
The email subject is dynamically generated
        ↓
The email body is dynamically generated
        ↓
The MailMessage object is created
        ↓
SMTP client is configured and email is sent
```
Especial Event
```text

The game starts
        ↓
The survival timer begins
        ↓
The player remains active in the game
        ↓
30 seconds elapse without losing
        ↓
The game detects the special event condition
        ↓
The email notification process is triggered
        ↓
The email subject is dynamically generated
        ↓
The email body is dynamically generated
        ↓
The MailMessage object is created
        ↓
Sender and recipient email addresses are assigned
        ↓
The SMTP client is configured
        ↓
Connection is established with smtp.gmail.com (port 587, SSL)
        ↓
The email is sent successfully
```
## **Server Response Handling**
```text

The system attempts to send the email (try block)
        ↓
Does the SMTP server respond correctly?
        ↓
        ├── Yes
        │     ↓
        │  Email is sent successfully
        │     ↓
        │  Success message is displayed in the UI
        │
        └── No
              ↓
         An exception is thrown
              ↓
         The error is captured (catch block)
              ↓
         Error message is displayed in the UI
```
