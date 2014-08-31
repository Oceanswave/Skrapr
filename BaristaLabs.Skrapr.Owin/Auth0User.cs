namespace BaristaLabs.Skrapr.Owin.Authentication
{
    using System;
    using System.Collections.Generic;
    using Auth0;
    using Nancy.Security;

    /// <summary>
    /// User that is used as the nancy context.CurrentUser when JWT bearer tokens are present.
    /// </summary>
    public class Auth0User : IUserIdentity
    {
        private readonly UserProfile m_userProfile;

        public Auth0User(UserProfile userProfile)
        {
            if (userProfile == null)
                throw new ArgumentNullException("userProfile");
            m_userProfile = userProfile;
        }

        public UserProfile UserProfile
        {
            get { return m_userProfile; }
        }

        public string UserName
        {
            get { return m_userProfile.UserId; }
            set { m_userProfile.UserId = value; }
        }

        public IEnumerable<string> Claims
        {
            get
            {
                var properties = new List<string> {
                    "email:" + m_userProfile.Email,
                    "familyName:" + m_userProfile.FamilyName,
                    "gender" + m_userProfile.Gender,
                    "givenName" + m_userProfile.GivenName,
                    "locale" + m_userProfile.Locale,
                    "name" + m_userProfile.Name, 
                    "nickname" + m_userProfile.Nickname,
                    "picture" + m_userProfile.Picture,
                    "userId" + m_userProfile.UserId, 
                };

                return properties;
            }
        }
    }
}