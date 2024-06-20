import 'dart:io';

import 'package:IB210370/configuration_manager.dart';
import 'package:dio/dio.dart';
import 'package:IB210370/modules/shared/utils/api/interceptors.dart';
import 'package:dio/io.dart';

class Api {
  final dio = createDio();
  // ignore: prefer_typing_uninitialized_variables
  final tokenDio;

  Api._internal()
      : tokenDio =
            Dio(BaseOptions(baseUrl: ConfigurationManager().config.apiUrl));

  static final _singleton = Api._internal();

  factory Api() => _singleton;

  static Dio createDio() {
    var url = ConfigurationManager().config.apiUrl;

    var dio = Dio(BaseOptions(
      baseUrl: url,
      receiveTimeout: const Duration(seconds: 10),
      connectTimeout: const Duration(seconds: 10),
      sendTimeout: const Duration(seconds: 10),
    ));

    dio.interceptors.addAll({
      AppInterceptors(dio),
    });

    // Allow self-signed certificate
    bool trustSelfSigned = true;
    (dio.httpClientAdapter as IOHttpClientAdapter).createHttpClient = () {
      final client = HttpClient();
      client.badCertificateCallback = (cert, host, port) => trustSelfSigned;
      return client;
    };

    return dio;
  }
}
