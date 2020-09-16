AirPressureTable = readtable('AirPressureData.csv');
t = 10;
for sn = 1:4
    fprintf('Weather Station #%i:\n', sn);
    stationRecords = AirPressureTable(AirPressureTable.SN == sn, :);
    sz = size(stationRecords);
    xs = stationRecords.T;
    ys = stationRecords.PM;
    lagrangeEstimation = LagrangeInterpolations(t, sz(1), xs, ys);
    fprintf('\t Lagrage Interpolations Estimation: %f\n', lagrangeEstimation);
    nevillesEstimation = NevillesMethod(t, sz(1), xs, ys);
    fprintf('\t Nevilles Estimation: %f\n', nevillesEstimation);
    newtonsEstimation = NewtonsDividedDifferences(t, sz(1), xs, ys);
    fprintf('\t Newton''s Divided Difference Estimation: %f\n', newtonsEstimation);
    fprintf('\n\n');
end