using System;
using System.Net;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SendEmail : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text statusText;

    int score = 0;
    float timer = 0f;
    bool gameActive = true;

    string fromEmail = "pruebasunity84@gmail.com";
    string password = "lkpa okqf skoo gtdk";
    public string toEmail = "";

    void Start()
    {
        UpdateUI();
        statusText.text = "Juego iniciado";
    }

    void Update()
    {
        if (!gameActive) return;

        timer += Time.deltaTime;

        if (timer >= 30f)
        {
            EmailSend(
                "¡Sobreviviste durante 30 segundos!",
                "El jugador sobrevivió 30 segundos sin perder ni ganar."
            );
            statusText.text = "Correo enviado: Evento especial";
            timer = 0f;
        }
    }

    public void AddPoint()
    {
        if (!gameActive) return;

        score++;
        UpdateUI();

        if (score >= 10)
        {
            gameActive = false;
            EmailSend(
                "Ganaste",
                "El jugador ganó al alcanzar 10 puntos."
            );
            statusText.text = "Correo enviado: Victoria";
        }
    }

    public void LoseGame()
    {
        if (!gameActive) return;

        score = 0;
        gameActive = false;
        UpdateUI();

        EmailSend(
            "Perdiste",
            "El jugador perdió al tocar un objeto peligroso."
        );
        statusText.text = "Correo enviado: Derrota";
    }

    void UpdateUI()
    {
        scoreText.text = "Puntaje: " + score;
    }

    void EmailSend(string subject, string body)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromEmail, password),
            EnableSsl = true
        };

        try
        {
            smtp.Send(mail);
            Debug.Log("Correo enviado correctamente");
        }
        catch (Exception ex)
        {
            Debug.Log("Error SMTP: " + ex.Message);
        }
    }
}