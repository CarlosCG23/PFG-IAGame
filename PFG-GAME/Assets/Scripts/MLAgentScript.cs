using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Buffers;
using UnityEngine.SceneManagement;

public class MLAgentScript : Agent
{
    //private bool actionTaken;
    /*
    private void Start()
    {
        // Asegurarse de que el objeto que contiene el script no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }
    
    public bool runInTrainingMode;

    private void Awake()
    {
        if (runInTrainingMode)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    */

    public override void OnEpisodeBegin()
    {
        // Indicar que no se ha tomado ninguna acci�n todav�a
        //actionTaken = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observar la cantidad de estrellas obtenidas y el nivel de dificultad actual
        sensor.AddObservation(StarManagerScript.StarCount);
        sensor.AddObservation(DifficultyManager.difficulty);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if(WinScript.gameStatus != -1)
        {
            // Tomar la acci�n elegida por el agente y actualizar la variable est�tica de nivel de dificultad
            var vectorAction = actionBuffers.DiscreteActions;
            DifficultyManager.difficulty = (int)vectorAction[0];
            //Debug.Log(DifficultyManager.difficulty);

            // Calcular y otorgar la recompensa seg�n el resultado de la partida
            float reward = 0f;
            if (WinScript.gameStatus == 0 && StarManagerScript.StarCount < 3)
            {
                reward = 1.0f;
            }
            else if (WinScript.gameStatus == 0 && StarManagerScript.StarCount == 3)
            {
                reward = -0.4f;
            }
            else if (WinScript.gameStatus == 1)
            {
                reward = -0.4f;
            }

            // Otorgar la recompensa al agente
            AddReward(reward);
            EndEpisode();
        }
    }
}

/*
    private int difficultyLevel;
    private int starsCollected;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public override void Initialize()
    {
        // Inicializar el agente
        //difficultyLevel = DifficultyManager.difficulty;
        //starsCollected = StarManagerScript.StarCount;
    }

    public override void OnEpisodeBegin()
    {
        // Reiniciar el entorno y establecer el nivel de dificultad inicial
        difficultyLevel = 0;
        starsCollected = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        if (WinScript.gameStatus != -1)
        {
            // Observaciones: nivel de dificultad y estrellas recolectadas
            difficultyLevel = DifficultyManager.difficulty;
            starsCollected = StarManagerScript.StarCount;

            sensor.AddObservation(difficultyLevel);
            sensor.AddObservation(starsCollected);
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Convertir las acciones discretas a valores enteros (0, 1, 2)
        int action = actionBuffers.DiscreteActions[0];

        // Actualizar el nivel de dificultad seg�n la acci�n elegida
        difficultyLevel = action;
        DifficultyManager.difficulty = difficultyLevel;
        SceneManager.LoadScene("SampleScene");
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        
    }

    public void EndGame(bool win, int starsCount)
    {
        // Calcular y otorgar la recompensa seg�n el resultado de la partida
        float reward = 0f;
        if (win && starsCount < 3)
        {
            reward = 1.0f;
        }
        else if (win && starsCount == 3)
        {
            reward = -0.4f;
        }
        else if (!win)
        {
            reward = -0.4f;
        }

        // Otorgar la recompensa al agente
        AddReward(reward);
        EndEpisode();
    }
    
     // Realizar acciones en funci�n del nivel de dificultad
        // ...

        // Evaluar recompensas en funci�n de los resultados
        float reward = 0f;

        if (IsWinConditionMet())
        {
            if (starsCollected == 3)
            {
                reward = -0.4f;
            }
            else
            {
                reward = 1.0f;
            }

            // Otorgar premios y reiniciar el entorno para el pr�ximo episodio
            starsCollected = 0;
            EndEpisode();
        }
        else if (IsLossConditionMet())
        {
            reward = -0.4f;

            // Reiniciar el entorno para el pr�ximo episodio
            EndEpisode();
        }

        // Aplicar la recompensa al agente
        AddReward(reward); 
     
    private bool IsWinConditionMet()
    {
        // Verificar si se cumple la condici�n de victoria
        // ...
        return false;
    }

    private bool IsLossConditionMet()
    {
        // Verificar si se cumple la condici�n de derrota
        // ...
        return false;
    }*/
