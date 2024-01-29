[System.Serializable]
public class User
{
    public string id;
    public string email;
    public string password;
    public string name;
    public string idAvatar;
    public int status;
    public string idCharacter;

    public User () { }
    public User (string id, string email, string password, string name, string idAvatar, int status, string idCharacter)
    {
        this.id = id;
        this.email = email;
        this.password = password;
        this.name = name;
        this.idAvatar = idAvatar;
        this.status = status;
        this.idCharacter = idCharacter;
    }
}
