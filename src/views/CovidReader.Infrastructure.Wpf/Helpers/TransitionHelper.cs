
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CovidReader.Infrastructure.Wpf.Helpers
{
    public enum ModalTransitionResponse
    {
        Yes,
        No,
        Cancel
    }

    public class TransitionHelper
    {

        //private InteractionMessenger messenger;

        //public void SetMessanger(InteractionMessenger messenger)
        //{
        //    this.messenger = messenger;
        //}

        //public ModalTransitionResponse TransitionModal<TView>(INotifyPropertyChanged viewModel)
        //{
        //    if (messenger == null)
        //        throw new InvalidOperationException("Messengerが設定されていません");

        //    var message = new TransitionMessage(typeof(TView), viewModel, TransitionMode.Modal, "ModalTransitionKey");

        //    messenger.Raise(message);

        //    return ConvertToResponse(message.Response);
        //}

        //private ModalTransitionResponse ConvertToResponse(bool? result)
        //{
        //    if(result.HasValue)
        //    {
        //        return result.Value ? ModalTransitionResponse.Yes : ModalTransitionResponse.No;
        //    }
        //    else
        //    {
        //        return ModalTransitionResponse.Cancel;
        //    }
        //}
    }
}
