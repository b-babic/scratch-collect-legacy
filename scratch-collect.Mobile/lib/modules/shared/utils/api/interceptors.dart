import 'package:dio/dio.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/bad_request.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/conflict_exception.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/deadline_exception.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/internal_server.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/no_internet_exception.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/not_found_exception.dart';
import 'package:scratch_collect/modules/shared/utils/api/errors/unauthorized_exception.dart';
import 'package:scratch_collect/modules/shared/utils/storage.dart';

class AppInterceptors extends Interceptor {
  final Dio dio;

  AppInterceptors(this.dio);

  // Autorization handlers
  @override
  void onRequest(
      RequestOptions options, RequestInterceptorHandler handler) async {
    var token = await Storage().read("token");

    if (token != null) {
      options.headers['Authorization'] = 'Bearer $token';
    }

    return handler.next(options);
  }

  // Error handling
  @override
  void onError(DioError err, ErrorInterceptorHandler handler) {
    switch (err.type) {
      case DioErrorType.connectTimeout:
      case DioErrorType.sendTimeout:
      case DioErrorType.receiveTimeout:
        throw DeadlineExceededException(err.requestOptions);
      case DioErrorType.response:
        switch (err.response?.statusCode) {
          case 400:
            throw BadRequestException(err.requestOptions, err.response);
          case 401:
            throw UnauthorizedException(err.requestOptions);
          case 404:
            throw NotFoundException(err.requestOptions);
          case 409:
            throw ConflictException(err.requestOptions);
          case 500:
            throw InternalServerErrorException(err.requestOptions);
        }
        break;
      case DioErrorType.cancel:
        break;
      case DioErrorType.other:
        throw NoInternetConnectionException(err.requestOptions);
    }
  }
}
