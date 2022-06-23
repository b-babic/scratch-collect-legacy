class ProfileResponse {
  int? id;
  String? username;
  String? email;
  String? firstName;
  String? lastName;
  String? address;
  String? registeredAt;
  String? userPhoto;

  ProfileResponse(
      {this.id,
      this.username,
      this.email,
      this.firstName,
      this.lastName,
      this.address,
      this.registeredAt,
      this.userPhoto});

  ProfileResponse.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    username = json['username'];
    email = json['email'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    address = json['address'];
    registeredAt = json['registeredAt'];
    userPhoto = json['userPhoto'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['username'] = username;
    data['email'] = email;
    data['firstName'] = firstName;
    data['lastName'] = lastName;
    data['address'] = address;
    data['registeredAt'] = registeredAt;
    data['userPhoto'] = userPhoto;

    return data;
  }
}
