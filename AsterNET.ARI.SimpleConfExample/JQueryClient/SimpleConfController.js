function ConfViewModel() {
    var self = this;
    self.confURI = 'http://localhost:9000/api/conference';

    self.confs = ko.observableArray();

    self.ajax = function (uri, method, data) {
        var request = {
            url: uri,
            type: method,
            contentType: "application/json",
            accepts: "application/json",
            cache: false,
            dataType: 'json',
            data: JSON.stringify(data),
            error: function (jqXHR) {
                console.log("ajax error " + jqXHR.status);
            }
        };
        return $.ajax(request);
    };

    self.ajax(self.confURI, 'GET').done(function (data) {
        for (var i = 0; i < data.length; i++) {
            self.confs.push({
                ConferenceName: ko.observable(data[i].ConferenceName),
                ConferenceId: ko.observable(data[i].Id),
                Uri: self.confURI + '/' + data[i].Id
            });
        }
    });

    self.muteConf = function (conf) {
        var muteUri = conf.Uri + '/Mute';
        self.ajax(muteUri, 'GET');
    };

    self.unmuteConf = function (conf) {
        var muteUri = conf.Uri + '/Unmute';
        self.ajax(muteUri, 'GET');
    };

    self.startMoh = function (conf) {
        var muteUri = conf.Uri + '/StartMOH?mohClass=default';
        self.ajax(muteUri, 'GET');
    };

    self.stopMoh = function (conf) {
        var muteUri = conf.Uri + '/StopMOH';
        self.ajax(muteUri, 'GET');
    };

    self.destroy = function (conf) {
        var muteUri = conf.Uri;
        self.ajax(muteUri, 'DELETE');
    };
}

$(document).ready(function() {
    ko.applyBindings(new ConfViewModel(), $('#main')[0]);
});