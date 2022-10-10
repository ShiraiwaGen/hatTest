using Microsoft.AspNetCore.Identity;

namespace Dairiten.Areas.Identity
{
    public class IdentityErrorDescriberJP : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"不明な障害が発生しました。" }; }
        public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "パスワードが正しくありません。" }; }
        public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "無効なトークン。" }; }
        public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "このログインを持つユーザーは既に存在します。" }; }
        public override IdentityError InvalidUserName(string userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"ユーザー名「{userName}」は無効です。文字または数字のみを使用できます。" }; }
        public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"ユーザー名「{userName}」は既に使用されています。" }; }
        public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "ユーザーはすでにパスワードを設定しています。" }; }
        public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"パスワードは {length} 文字以上にする必要があります。" }; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "パスワードには英数字以外の文字が少なくとも1つ含まれている必要があります。" }; }
        public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "パスワードには、少なくとも1つの数字 ('0' から '9') が必要です。" }; }
        public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "パスワードには、少なくとも1つの小文字 ('a'-'z') が必要です。" }; }
        public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "パスワードには、少なくとも1つの大文字 ('A'-'Z') が必要です。" }; }
    }
}
