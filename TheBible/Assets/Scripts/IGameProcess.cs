using System.Collections;

public interface IGameProcess
{
    event System.Action GameStart;
    event System.Action GameComplete;
    event System.Action GameOver;
}
