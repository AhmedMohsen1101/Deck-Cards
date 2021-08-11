using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deckcard
{
    public class DeckCardPresenter : MonoBehaviour
    {
        private DeckCardModel _model;

        [SerializeField] private DeckCardView _view = null;

        public void Initialize()
        {
            _model = new DeckCardModel();
            _view.Initialize();
        }
    }
}
