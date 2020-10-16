function largrangeEstimation = LagrangeInterpolations(x, n, xs, ys, debug)
    if ~exist('debug', 'var')
        debug = false;
    end
    largrangeEstimation = 0;
    Ls = ones(1,n);
    for i = 1:n
        for j = 1:n
            if i ~= j
                Ls(i) = Ls(i) * (x - xs(j)) / (xs(i) - xs(j));
            end
        end
    end
    
    if debug
        disp(Ls);
    end
    for i = 1:n
        largrangeEstimation = largrangeEstimation + Ls(i) * ys(i);
    end
end