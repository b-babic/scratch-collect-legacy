import 'dart:convert';

import 'package:scratch_collect/modules/profile/models/edit_password.request.dart';
import 'package:scratch_collect/modules/profile/models/edit_profile_request.dart';
import 'package:scratch_collect/modules/profile/models/profile.model.dart';
import 'package:scratch_collect/modules/profile/models/profile_request.model.dart';
import 'package:scratch_collect/modules/shared/utils/api/api.dart';
import 'package:scratch_collect/modules/shared/utils/secure_storage.dart';

class ProfileService {
  static ProfileService? _instance;

  factory ProfileService() => _instance ??= ProfileService._();

  ProfileService._();

  Future<ProfileResponse> getUserProfile(ProfileRequest request) async {
    var id = request.id;

    var response = await Api().dio.get('/user/profile/$id');

    return ProfileResponse.fromJson(response.data);
  }

  Future<ProfileResponse> updateProfile(EditProfileRequest request) async {
    var id = request.id;

    var response = await Api()
        .dio
        .patch('/user/profile/$id', data: jsonEncode(request.toJson()));

    return ProfileResponse.fromJson(response.data);
  }

  Future<ProfileResponse> updatePassword(EditPasswordRequest request) async {
    var id = request.id;

    var response = await Api().dio.patch('/user/profile/$id/password',
        data: jsonEncode(request.toJson()));

    return ProfileResponse.fromJson(response.data);
  }

  Future<ProfileResponse> getPersistedProfile() async {
    var persisted = await SecureStorage().read("profile");

    return ProfileResponse.fromJson(json.decode(persisted ?? "{}"));
  }
}
