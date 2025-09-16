using System;
using Protrack.Domain.Constants;

namespace Protrack.Domain.Entities;

public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string EmailAddress { get; private set; }
    public string Password { get; private set; }
    public bool MfaAuthenticated { get; private set; }
    public bool MfaEnabled { get; private set; } = true;
    public int LoginAttempts { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTimeOffset.UtcNow.DateTime;
    public Guid? CreatedBy { get; private set; }
    public DateTime UpdatedAt { get; private set; } = DateTimeOffset.UtcNow.DateTime;
    public Guid? UpdatedBy { get; set; }

    private User()
    {
    }

    public class Builder
    {
        private Guid _id = Guid.Empty;
        private string _username = string.Empty;
        private string _emailAddress = string.Empty;
        private string _password = string.Empty;
        private bool _mfaAuthenticated;
        private bool _mfaEnabled;
        private int _loginAttempts;
        private Guid _createdBy = Guid.Empty;
        private DateTime _createdAt = DateTimeOffset.UtcNow.DateTime;
        private Guid _updatedBy = Guid.Empty;
        private DateTime _updatedAt = DateTimeOffset.UtcNow.DateTime;

        public Builder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public Builder WithUsername(string username)
        {
            _username = username;
            return this;
        }

        public Builder WithEmailAddress(string emailAddress)
        {
            _emailAddress = emailAddress;
            return this;
        }

        public Builder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public Builder WithMfaAuthenticated(bool mfaAuthenticated)
        {
            _mfaAuthenticated = mfaAuthenticated;
            return this;
        }

        public Builder WithMfaEnabled(bool mfaEnabled)
        {
            _mfaEnabled = mfaEnabled;
            return this;
        }

        public Builder WithLoginAttempts(int loginAttempts)
        {
            _loginAttempts = loginAttempts;
            return this;
        }
        
        public Builder WithCreatedBy(Guid id)
        {
            _createdBy = id;
            return this;
        }
        
        public Builder WithCreatedAt(DateTime datetime)
        {
            _createdAt = datetime;
            return this;
        }
        
        public Builder WithUpdatedBy(Guid id)
        {
            _updatedBy = id;
            return this;
        }
        
        public Builder WithUpdatedAt(DateTime datetime)
        {
            _updatedAt = datetime;
            return this;
        }

        public User Build()
        {
            if (string.IsNullOrEmpty(_username))
            {
                throw new ArgumentNullException(UserConstants.UsernameRequired);
            }

            if (string.IsNullOrEmpty(_emailAddress))
            {
                throw new ArgumentNullException(UserConstants.EmailAddressRequired);
            }

            if (string.IsNullOrEmpty(_password))
            {
                throw new ArgumentNullException(UserConstants.PasswordRequired);
            }

            return new User
            {
                UserId = _id,
                Username = _username,
                EmailAddress = _emailAddress,
                Password = _password,
                MfaAuthenticated = _mfaAuthenticated,
                MfaEnabled = _mfaEnabled,
                LoginAttempts = _loginAttempts,
                CreatedBy = _createdBy,
                CreatedAt = _createdAt,
                UpdatedBy = _updatedBy,
                UpdatedAt = _updatedAt
            };
        }
    }

    public void UpdateUsername(string username, Guid updatedBy)
    {
        Username = username;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.DateTime;
    }
    
    public void UpdateEmailAddress(string emailAddress, Guid updatedBy)
    {
        EmailAddress = emailAddress;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.DateTime;
    }

    public void UpdatePassword(string password, Guid updatedBy)
    {
        Password = password;
        UpdatedBy = updatedBy;
        UpdatedAt = DateTimeOffset.UtcNow.DateTime;
    }

    public void EnableOrDisableMfa()
    {
        MfaEnabled = !MfaEnabled;
        UpdatedAt = DateTimeOffset.UtcNow.DateTime;
    }

    public void ResetLoginAttempts()
    {
        LoginAttempts = 0;
    }

    public void IncreaseLoginAttempt()
    {
        LoginAttempts++;
    }
}