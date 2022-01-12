namespace Sample.Droid.Messaging;

public interface IMessaging
{
    void ActionSheet();

    void ActionSheetBottom();

    void Alert();

    void Confirm();

    void Delete();

    void Loading();

    void Login();

    void Prompt();

    void Snackbar();

    void Toast();
}