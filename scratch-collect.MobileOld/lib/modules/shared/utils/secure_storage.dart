import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class SecureStorage {
  final instance = const FlutterSecureStorage();

  // Options
  AndroidOptions _getAndroidOptions() => const AndroidOptions(
        encryptedSharedPreferences: true,
      );

  // Handlers
  Future<void> write(String key, String value) async {
    return await instance.write(
        key: key, value: value, aOptions: _getAndroidOptions());
  }

  Future<String?> read(String key) async {
    return await instance.read(key: key, aOptions: _getAndroidOptions());
  }

  Future<void> delete(String key) async {
    return await instance.delete(key: key, aOptions: _getAndroidOptions());
  }

  Future<void> flush() async {
    return await instance.deleteAll();
  }
}
