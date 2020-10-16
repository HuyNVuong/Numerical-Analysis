function nevillesEstimation = NevillesMethod(x, n, xs, ys, debug)
    if ~exist('debug', 'var')
        debug = false;
    end
    Q = zeros(n, n);
    for i = 1:n
        Q(i,1) = ys(i);
    end
    for j = 2:n
        for i = j+1:n+1
            Q(i-1,j) = (x - xs(i - j)) * Q(i - 1,j - 1) / (xs(i - 1) - xs(i - j)) + ...
                (xs(i - 1) - x) * Q(i - 2,j - 1) / (xs(i - 1) - xs(i - j));
        end
    end
    
    if debug
        disp(Q);
    end
    
    nevillesEstimation = Q(n,n);
end
