import 'dart:convert';

import 'package:IB210370/modules/auth/models/signin_request.model.dart';
import 'package:IB210370/modules/auth/models/signin_response.dart';
import 'package:IB210370/modules/auth/models/signup_request.model.dart';
import 'package:IB210370/modules/profile/models/profile.model.dart';
import 'package:IB210370/modules/shared/utils/api/api.dart';
import 'package:IB210370/modules/shared/utils/secure_storage.dart';

class AuthService {
  static AuthService? _instance;

  factory AuthService() => _instance ??= AuthService._();

  AuthService._();

  Future<SigninResponse> signin(SigninRequest request) async {
    var response = await Api()
        .dio
        .post('/auth/signin', data: jsonEncode(request.toJson()));

    return SigninResponse.fromJson(response.data);
  }

  Future<ProfileResponse> signup(SignupRequest request) async {
    var response = await Api()
        .dio
        .post('/auth/signup', data: jsonEncode(request.toJson()));

    return ProfileResponse.fromJson(response.data);
  }

  Future<void> logout() async {
    return await SecureStorage().flush();
  }

  Future<SigninResponse> getPersistedUser() async {
    var persisted = await SecureStorage().read("user");

    return SigninResponse.fromJson(json.decode(persisted ?? "{}"));
  }
}
