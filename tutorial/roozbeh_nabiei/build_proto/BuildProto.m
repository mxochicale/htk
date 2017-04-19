function [ ] = BuildProto( destination, name, states, component )
%BUILDPROTO Summary of this function goes here
%   Detailed explanation goes here

f1 = fopen([destination name], 'w');

fprintf(f1,'~h "%s"\n',name);
fprintf(f1,'<BeginHMM>\n');
fprintf(f1,'<STREAMINFO> 1 %d\n',component);
fprintf(f1,'<VECSIZE> %d<NULLD><USER><DIAGC>\n',component);
fprintf(f1,'<NumStates> %d\n',states);
for i = 2:states-1
    fprintf(f1,'<State> %d\n',i);
    fprintf(f1,'<Mean> %d\n',component);
    for j=1:component
        if j == component
            fprintf(f1,'0.0\n');
        else
            fprintf(f1,'0.0 ');
        end;
    end;

    fprintf(f1,'<Variance> %d\n',component);
    for j=1:component
        if j == component
            fprintf(f1,'1.0\n');
        else
           fprintf(f1,'1.0 ');
        end;
    end;
end;
fprintf(f1,'<TransP> %d\n',states);

for i=1:states
    for j=1:states
        if i == 1
           if j==2
               fprintf(f1,'1.0 ');
           elseif j==states
               fprintf(f1,'0.0\n');
           else
               fprintf(f1,'0.0 ');
           end;
        elseif i==states
           if j==states
               fprintf(f1,'0.0\n');
           else
               fprintf(f1,'0.0 ');
           end;
        else
            if j==i || j==i+1
                if i==states-1 && j==i+1
                    fprintf(f1,'0.5\n');
                else
                    fprintf(f1,'0.5 ');
                end;
            elseif j==states
                fprintf(f1,'0.0\n');
            else
                fprintf(f1,'0.0 ');
            end;
        end;
    end;
end;
fprintf(f1,'<EndHMM>\n');
fclose('all');
end
