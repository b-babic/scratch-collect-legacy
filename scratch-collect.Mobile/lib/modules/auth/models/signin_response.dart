class SigninResponse {
  int? id;
  String? email;
  String? token;

  SigninResponse({this.id, this.email, this.token});

  SigninResponse.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    email = json['email'];
    token = json['token'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['id'] = id;
    data['email'] = email;
    data['token'] = token;

    return data;
  }
}
