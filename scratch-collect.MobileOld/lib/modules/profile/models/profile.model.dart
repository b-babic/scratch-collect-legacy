import 'package:IB210370/modules/wallet/models/wallet.model.dart';

class ProfileResponse {
  int? id;
  String? username;
  String? email;
  String? firstName;
  String? lastName;
  String? address;
  String? registeredAt;
  String? userPhoto;
  Wallet? wallet;

  ProfileResponse({
    this.id,
    this.username,
    this.email,
    this.firstName,
    this.lastName,
    this.address,
    this.wallet,
    this.registeredAt,
    this.userPhoto,
  });

  ProfileResponse.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    username = json['username'];
    email = json['email'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    address = json['address'];
    wallet = json['wallet'] != null ? Wallet.fromJson(json['wallet']) : null;
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
    data['wallet'] = wallet;
    data['registeredAt'] = registeredAt;
    data['userPhoto'] = userPhoto;

    return data;
  }
}
