using UnityEngine.UI;
using Unity;


public class Castor

{
    private static readonly ILog log = LogManager.GetLogger("Plus.HabboHotel.Users");

    //Generic castor values.
    private int _id;
    private string _username;
    private int _rank;
    private int _credits;
    private int _diamonds;
    private int _homeRoom;
    private double _lastOnline;
    private double _accountCreated;

    //Castor player saving.
    private bool _disconnected;

    public Castor(int Id, string Username, int Rank, int Credits, int HomeRoom, int LastOnline, int Diamonds, double AccountCreated)
    {
        this._id = Id;
        this._username = Username;
        this._rank = Rank;
        this._credits = Credits;
        this._diamonds = Diamonds;
        this._homeRoom = HomeRoom;
        this._lastOnline = LastOnline;
        this._accountCreated = AccountCreated;
        

        public int Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Username
        {
            get { return this._username; }
            set { this._username = value; }
        }

        public int Rank
        {
            get { return this._rank; }
            set { this._rank = value; }
        }
        public int Credits
        {
            get { return this._credits; }
            set { this._credits = value; }
        }
        public int Diamonds
        {
            get { return this._diamonds; }
            set { this._diamonds = value; }
        }

        public int HomeRoom
        {
            get { return this._homeRoom; }
            set { this._homeRoom = value; }
        }
    
        public void OnDisconnect()
        {
            if (this._disconnected)
            {
                return;
            }
               
        }
    }

}