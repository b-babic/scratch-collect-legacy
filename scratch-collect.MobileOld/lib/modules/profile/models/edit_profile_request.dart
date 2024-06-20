class EditProfileRequest {
  int? id;
  String? email;
  String? username;
  String? firstName;
  String? lastName;
  String? address;

  EditProfileRequest(
      {this.id,
      this.email,
      this.username,
      this.firstName,
      this.lastName,
      this.address});

  EditProfileRequest.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    email = json['id'];
    username = json['username'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    address = json['address'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['email'] = email;
    data['username'] = username;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['address'] = address;

    return data;
  }
}
