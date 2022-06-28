class SignupRequest {
  String? email;
  String? password;
  String? passwordConfirm;
  String? username;
  String? firstName;
  String? lastName;
  String? address;

  SignupRequest(
      {this.email,
      this.password,
      this.passwordConfirm,
      this.username,
      this.firstName,
      this.lastName,
      this.address});

  SignupRequest.fromJson(Map<String, dynamic> json) {
    email = json['email'];
    password = json['password'];
    passwordConfirm = json['passwordConfirm'];
    username = json['username'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    address = json['address'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['email'] = email;
    data['password'] = password;
    data['passwordConfirm'] = passwordConfirm;
    data['username'] = username;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['address'] = address;

    return data;
  }
}
