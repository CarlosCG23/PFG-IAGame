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
    //private bool actionTaken;
    /*
    private void Start()
    {
        // Asegurarse de que el objeto que contiene el script no se destruya al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }
    */
    private static MLAgentScript instance;
    private int lastDifficulty;
    private int actionDifficulty;

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
        // Indicar que no se ha tomado ninguna acción todavía
        //actionTaken = false;
        lastDifficulty = DifficultyManager.difficulty;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observar la cantidad de estrellas obtenidas y el nivel de dificultad actual
        sensor.AddObservation(StarManagerScript.StarCount);
        //sensor.AddObservation(DifficultyManager.difficulty);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        if(WinScript.gameStatus != -1)
        {
            // Tomar la acción elegida por el agente y actualizar la variable estática de nivel de dificultad
            var vectorAction = actionBuffers.DiscreteActions;
            actionDifficulty = (int)vectorAction[0];
            //Debug.Log(actionDifficulty);

            // Calcular y otorgar la recompensa según el resultado de la partida
            if (WinScript.gameStatus == 0 && StarManagerScript.StarCount < 3)
            {
                if (lastDifficulty == actionDifficulty)
                {
                    // Otorgar la recompensa al agente
                    AddReward(1.0f); 
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
                else if (lastDifficulty > actionDifficulty || lastDifficulty < actionDifficulty)
                {
                    // Otorgar la recompensa al agente
                    AddReward(-0.8f);
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
            }
            else if (WinScript.gameStatus == 0 && StarManagerScript.StarCount == 3)
            {
                if (lastDifficulty < actionDifficulty || actionDifficulty == 2)
                {
                    // Otorgar la recompensa al agente
                    AddReward(1.0f);
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
                else if (lastDifficulty > actionDifficulty || (lastDifficulty == actionDifficulty && actionDifficulty != 3))
                {
                    // Otorgar la recompensa al agente
                    AddReward(-0.8f);
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
            }
            else if (WinScript.gameStatus == 1)
            {
                if (lastDifficulty > actionDifficulty || actionDifficulty == 0)
                {
                    // Otorgar la recompensa al agente
                    AddReward(1.0f);
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
                else if ((actionDifficulty != 0 && lastDifficulty == actionDifficulty) || lastDifficulty < actionDifficulty)
                {
                    // Otorgar la recompensa al agente
                    AddReward(-0.8f);
                    DifficultyManager.difficulty = actionDifficulty;
                    EndEpisode();
                }
            }
        }
    }
}