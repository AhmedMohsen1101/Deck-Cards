using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenterController : MonoBehaviour
{
    private List<IPresenter> presenters;


    public void SetPresenter(IPresenter presenter)
    {
        presenters = presenters ?? new List<IPresenter>();
        presenters.Add(presenter);
        presenter.SetController(this);
    }
    public void RemovePresenter(IPresenter presenter)
    {
        presenters.Remove(presenter);
    }
}

public interface IPresenter
{
    void SetController(PresenterController presenterController);
}
