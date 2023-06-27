using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using System.Buffers;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MLAgentScript : Agent
{
    private static MLAgentScript instance;
    private int lastDifficulty;
    private int difficulty;

    private void Awake()
    {
        // Verificar si ya existe una instancia del objeto
        if (instance == null)
        {
            // Mantener esta instancia y evitar que se destruya al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    public override void OnEpisodeBegin()
    {

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observar la cantidad de estrellas obtenidas y el nivel de dificultad actual
        sensor.AddObservation(StarManagerScript.StarCount);
        sensor.AddObservation(DifficultyManager.difficulty);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if (WinScript.gameStatus != -1)
        {
            // Tomar la acción elegida por el agente y actualizar la variable estática de nivel de dificultad
            int NextActionDifficulty = actionBuffers.DiscreteActions[0];
            Debug.Log(NextActionDifficulty);

            // Calcular y otorgar la recompensa según el resultado de la partida
            if (StarManagerScript.StarCount == 1 || StarManagerScript.StarCount == 2) // se mantiene
            {
                if(NextActionDifficulty == DifficultyManager.difficulty)
                {
                    SetReward(1f);
                }
                else
                {
                    SetReward(-1f);
                }
            }
            if (StarManagerScript.StarCount == 3) // aumenta
            {
                if(NextActionDifficulty > DifficultyManager.difficulty || NextActionDifficulty == 3)
                {
                    SetReward(1f);
                }
                else if(NextActionDifficulty < DifficultyManager.difficulty)
                { 
                    SetReward(-1f); 
                }
            }
            if (StarManagerScript.StarCount == 0) // Disminuye
            {
                if (NextActionDifficulty < DifficultyManager.difficulty || NextActionDifficulty == 0)
                {
                    SetReward(1f);
                }
                else if (NextActionDifficulty > DifficultyManager.difficulty)
                {
                    SetReward(-1f);
                }
            }
            DifficultyManager.difficulty = NextActionDifficulty;
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        /*
        if (Input.GetKeyDown(KeyCode.G))
        {
            difficulty = 0;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            difficulty = 1;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            difficulty = 2;
        }
        */
        difficulty = DifficultyManager.difficulty;
        if (WinScript.gameStatus == 0)
        {
            if (StarManagerScript.StarCount == 3)
            {
                difficulty = difficulty + 1;
                
                if (difficulty >= 2)
                {
                    difficulty = 2;
                }
            }
        }
        else if (WinScript.gameStatus == 1)
        {
            difficulty = difficulty - 1;
            if (difficulty <= 0)
            {
                difficulty = 0;
            }
        }
        actionsOut.DiscreteActions.Array[0] = difficulty;
    } 
}