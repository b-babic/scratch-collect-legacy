class RatingRequest {
  int? userId;
  int? offerId;
  double? rateCount;

  RatingRequest({
    this.userId,
    this.offerId,
    this.rateCount,
  });

  RatingRequest.fromJson(Map<String, dynamic> json) {
    userId = json['userId'];
    offerId = json['offerId'];
    rateCount = json['rateCount'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};

    data['userId'] = userId;
    data['offerId'] = offerId;
    data['rateCount'] = rateCount;

    return data;
  }
}
