using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presenter
{
    public class Presenter : IPresenter
    {
        View.IView view;
        Model.Model deckModel;
        public Presenter(View.IView view)
        {
            deckModel = new Model.Model();

            this.view = view;
        }

    }

}
