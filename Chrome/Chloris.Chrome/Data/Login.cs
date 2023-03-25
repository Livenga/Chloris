namespace Chloris.Chrome.Data;

// logins
//     origin_url               System.String
//     action_url               System.String
//     username_element         System.String
//     username_value           System.String
//     password_element         System.String
//     password_value           System.Byte[]
//     submit_element           System.String
//     signon_realm             System.String
//     date_created             System.Int64
//     blacklisted_by_user      System.Int64
//     scheme                   System.Int64
//     password_type            System.Int64
//     times_used               System.Int64
//     form_data                System.Byte[]
//     display_name             System.String
//     icon_url                 System.String
//     federation_url           System.String
//     skip_zero_click          System.Int64
//     generation_upload_status System.Int64
//     possible_username_pairs  System.Byte[]
//     id                       System.Int64
//     date_last_used           System.Int64
//     moving_blocked_for       System.Byte[]
//     date_password_modified   System.Int64


/// <summary></summary>
public class Login
{
    /// <summary></summary>
    public long Id { set; get; } = 0;

    /// <summary></summary>
    public string OriginUrl { set; get; } = string.Empty;

    /// <summary></summary>
    public string ActiveUrl { set; get; } = string.Empty;

    /// <summary></summary>
    public string? UsernameElement { set; get; } = null;

    /// <summary></summary>
    public string? UserNameValue { set; get; } = null;

    /// <summary></summary>
    public string? PasswordElement { set; get; } = null;

    /// <summary></summary>
    public byte[]? PasswordValue { set; get; } = null;

    /// <summary></summary>
    public long DateCreated { set; get; } = 0;

    /// <summary></summary>
    public long PasswordType { set; get; } = 0;

    /// <summary></summary>
    public long? DateLastUsed { set; get; } = null;
}
