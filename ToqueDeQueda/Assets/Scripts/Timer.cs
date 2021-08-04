using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Timer : MonoBehaviour
{
    private Text textClock;
    public int hour;
    public int minute;
    public GameObject curfewText;

    // Esta funcion es llamada cuando compile el juego
    private void Awake() {
        textClock = GetComponent<Text>();
    }

    // Esta funcion es llamada cuando inicie el juego
    private void Start() {
        updateTextClock();
        InvokeRepeating("passMinute", 0, 3.0f);
    }

    // Pasa un minuto en el juego
    private void passMinute() {
        minute += 1;
        passHour();
        updateTextClock();
    }

    // Verifica si pasa una hora en el juego
    private void passHour() {
        if (minute >= 60) {
            minute = 0;
            hour += 1;
        }
        checkCurfew();
        passDay();
    }

    // Verifica si pasa un dia en el juego
    private void passDay() {
        if (hour >= 24) {
            hour = 0;
        }
    }

    private void checkCurfew() {
        if (hour > 19 || hour < 7) {
            showCurfewText();
        }
    }

    private void showCurfewText() {
        curfewText.GetComponent<Text>().enabled = true;
    }

    // Actualiza el texto del reloj del juego
    private void updateTextClock() {
        string textHour = leadingZero(hour);
        string textMinute = leadingZero(minute);
        textClock.text = textHour + ":" + textMinute;
    }

    // Pasa el tiempo a texto
    private string leadingZero(int n) {
        return n.ToString().PadLeft(2, '0');
    }
}
