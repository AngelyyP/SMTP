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
## Basic SMTP Sending Flow
| Step | Action | Component / Script | Result |
|-----:|--------|-------------------|--------|
| 1 | Game starts | `SendEmail.Start()` | Score initialized, UI updated, game active |
| 2 | Player moves | `PlayerMovement.Update()` | Player moves using keyboard input |
| 3 | Player collides with object | `PlayerCollision.OnTriggerEnter()` | Collision detected |
| 4 | Collision with **Good** object | `CompareTag("Good")` | `AddPoint()` method is called |
| 5 | Score increases | `SendEmail.AddPoint()` | Score updated on screen |
| 6 | Score reaches 10 | `SendEmail.AddPoint()` | Victory condition detected |
| 7 | Victory email is generated | `EmailSend(subject, body)` | Dynamic subject and body created |
| 8 | Email sent via SMTP | `SmtpClient.Send()` | Email transmitted to SMTP server |
| 9 | Status shown in UI | `statusText (TMP_Text)` | “Correo enviado: Victoria” |
|10 | Collision with **Bad** object | `CompareTag("Bad")` | `LoseGame()` method is called |
|11 | Score reset to 0 | `SendEmail.LoseGame()` | Game over condition |
|12 | Defeat email is generated | `EmailSend(subject, body)` | Dynamic defeat message created |
|13 | Email sent via SMTP | `SmtpClient.Send()` | Email transmitted |
|14 | Status shown in UI | `statusText (TMP_Text)` | “Correo enviado: Derrota” |
|15 | Player survives 30 seconds | `SendEmail.Update()` | Timer reaches 30 seconds |
|16 | Special event detected | `timer >= 30f` | Special event triggered |
|17 | Special event email generated | `EmailSend(subject, body)` | Dynamic special event message |
|18 | Email sent via SMTP | `SmtpClient.Send()` | Email transmitted |
|19 | Status shown in UI | `statusText (TMP_Text)` | “Correo enviado: Evento especial” |

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
