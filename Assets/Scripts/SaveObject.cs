/*Christian Cerezo*/
[System.Serializable]

public class SaveObject
{
    // Fields to be saved in JSON format: must be public and able to be serializable
    public int GameDifficulty;
    public float TimeElapsed;
    public bool NewGame;

    public SaveObject()
    {
        this.GameDifficulty = 0;
        this.TimeElapsed = 0;
        this.NewGame = true;
    }

}
